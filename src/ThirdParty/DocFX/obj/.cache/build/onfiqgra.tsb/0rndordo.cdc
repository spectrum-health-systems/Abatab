<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>About the Abatab logging </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="About the Abatab logging ">
    <meta name="generator" content="docfx 2.59.4.0">
    
    <link rel="shortcut icon" href="../../favicon.ico">
    <link rel="stylesheet" href="../../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../../styles/docfx.css">
    <link rel="stylesheet" href="../../styles/main.css">
    <meta property="docfx:navrel" content="../../toc.html">
    <meta property="docfx:tocrel" content="../toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../../index.html">
                <img id="logo" class="svg" src="../../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="">

<div align="center">

  <img src="../../images/man-logo.png" alt="Abatab Manual" width="512">

  <h4>
    Abatab v22.12.0
  </h4>

</div>

<hr>
<h1 id="about-the-abatab-logging" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="12" sourceendlinenumber="12">About the Abatab logging</h1>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="14" sourceendlinenumber="14">Abatab has extensive built-in logging functionality.</p>
<h2 id="debug-logs" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="16" sourceendlinenumber="16">Debug logs</h2>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="18" sourceendlinenumber="18">Debug logs are only created when <a href="https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#DebugMode" data-raw-source="[`DebugMode`](https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#DebugMode)" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="18" sourceendlinenumber="18"><code>DebugMode</code></a> is set to <code>on</code>.    </p>
<ul sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="19" sourceendlinenumber="20">
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="19" sourceendlinenumber="19">DebugMode should only be used while developing Abatab</li>
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="20" sourceendlinenumber="20">There is a hardcoded 10ms delay when writing a debug logfile, so DebugMode will have an impact on performance.</li>
</ul>
<h3 id="built-in-debug-statements" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="22" sourceendlinenumber="22">Built-in debug statements</h3>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="24" sourceendlinenumber="24">Most methods start with a a built-in debug statements, which have a <code>[DEBUG]</code> message. These debug statements are part of the code, and should not be removed.</p>
<pre sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="26" sourceendlinenumber="28"><code class="lang-bash">LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, &quot;[DEBUG]&quot;);
</code></pre><h3 id="custom-debug-statements" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="29" sourceendlinenumber="29">Custom debug statements</h3>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="31" sourceendlinenumber="31">You can create your own debug statements by customizing the message. Temporary debug statments should be removed from production code.</p>
<pre sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="33" sourceendlinenumber="35"><code class="lang-bash">LogEvent.Debug(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugglerConfig.Mode, abatabSession.DebugglerConfig.DebugEventRoot, $&quot;VariableName value is {value}&quot;);
</code></pre><h3 id="primeval-debug-log" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="37" sourceendlinenumber="37">Primeval debug log</h3>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="39" sourceendlinenumber="39">The Primeval debug log file is the first line of Abatab.asmx.cs, and writes a debug logfile with the most basic, hardcoded setting information.</p>
<pre sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="41" sourceendlinenumber="43"><code class="lang-bash">LogEvent.PrimevalDebug(Settings.Default.DebugMode, Assembly.GetExecutingAssembly().GetName().Name, $@&quot;{Settings.Default.AbatabRoot}{Settings.Default.AbatabEnvironment}\{Settings.Default.DebugLogRoot}&quot;);
</code></pre><h3 id="the-debuggler" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="45" sourceendlinenumber="45">The Debuggler</h3>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="47" sourceendlinenumber="47">Abatab can write debug files for debug logs, but this should <em>only</em> be used in development, as it will introduce <em>significant</em> performance issues.</p>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="49" sourceendlinenumber="49">As such, enabling the debuggler can only be done in the source code by changing the following line in <code>AbatabLogging.LogEvent.Debug()</code> from</p>
<pre sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="51" sourceendlinenumber="53"><code class="lang-bash">const bool debugDebugger = false;
</code></pre><p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="54" sourceendlinenumber="54">to</p>
<pre sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="56" sourceendlinenumber="58"><code class="lang-bash">const bool debugDebugger = true;
</code></pre><h2 id="trace-logs" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="60" sourceendlinenumber="60">Trace logs</h2>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="62" sourceendlinenumber="62">Trace logs are designed to let you follow what is happening during an Abatab session, and can be helpful when troubleshooting. As such, trace statemnts are abundant.</p>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="64" sourceendlinenumber="64">Trace logs are only created when <a href="https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#LogMode" data-raw-source="[`LogMode`](https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#LogMode)" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="64" sourceendlinenumber="64"><code>LogMode</code></a> contains <code>trace</code>.</p>
<ul sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="66" sourceendlinenumber="67">
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="66" sourceendlinenumber="66">Trace logs should generally be used when troubleshooting development builds, although they can be enabled in production.</li>
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="67" sourceendlinenumber="67">There is a global <a href="(https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#LogWriteDelay)" data-raw-source="[delay]((https://spectrum-health-systems.github.io/Abatab/articles/SourceCode/LocalSettings.html#LogWriteDelay))" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="67" sourceendlinenumber="67">delay</a> when writing log files, so enabling trace logs may have an negative impact on performance.</li>
</ul>
<h4 id="a-note-about-trace-logs-in-abatablogginglogeventcs" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="69" sourceendlinenumber="69">A note about trace logs in AbatabLogging.LogEvent.cs</h4>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="71" sourceendlinenumber="71">Log statements in AbatabLogging.LogEvent.cs don&#39;t follow most of the standards below, since it&#39;s not easy to log the thing that&#39;s creating the thing that&#39;s logging a thing. Or something.</p>
<h3 id="built-in-trace-statements" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="73" sourceendlinenumber="73">Built-in trace statements</h3>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="75" sourceendlinenumber="75">Trace statements can be found:</p>
<ul sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="76" sourceendlinenumber="78">
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="76" sourceendlinenumber="76">At the beginning of methods, immediately following debug statements</li>
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="77" sourceendlinenumber="77">At the beginning of any conditional statements, loops, or other expressions</li>
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="78" sourceendlinenumber="78">When it would be helpful to know where Abatab is</li>
</ul>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="80" sourceendlinenumber="80">These trace statements are part of the code, and should not be removed.</p>
<pre sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="82" sourceendlinenumber="84"><code class="lang-bash">LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, &quot;[TRACE]&quot;);
</code></pre><h3 id="custom-trace-statements" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="86" sourceendlinenumber="86">Custom trace statements</h3>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="88" sourceendlinenumber="88">You can create your own trace statements by customizing the message. Temporary trace statments should be removed from production code.</p>
<pre sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="90" sourceendlinenumber="92"><code class="lang-bash">LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, $&quot;VariableName value is {value}&quot;);
</code></pre><h2 id="session-logs" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="94" sourceendlinenumber="94">Session logs</h2>
<h2 id="access-logs" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="96" sourceendlinenumber="96">Access logs</h2>
<h2 id="lost-logs" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="98" sourceendlinenumber="98">Lost logs</h2>
<h1 id="variables" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="101" sourceendlinenumber="101">Variables</h1>
<h2 id="prefixes" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="103" sourceendlinenumber="103">Prefixes</h2>
<ul sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="105" sourceendlinenumber="110">
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="105" sourceendlinenumber="106"><code>sent</code><br>If a variable name starts with &quot;sent&quot; (e.g., <code>sentValue</code>), the data it contains original data that should not be modified at any point.</li>
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="107" sourceendlinenumber="108"><code>work</code><br>If a variable name starts with &quot;work&quot; (e.g., <code>workDictionary</code>), it will be used as a placeholder for modified data. </li>
<li sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="109" sourceendlinenumber="110"><code>final</code><br>If a variable name starts with &quot;final&quot; (e.g., <code>finalValue</code>), the data is in it&#39;s final form, and is most likely what will be returned from a method.</li>
</ul>
<h2 id="casing-and-trimming" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="112" sourceendlinenumber="112">Casing and trimming</h2>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="114" sourceendlinenumber="114">Most logic in Abatab is checked against lowercase values without any leading/trailing whitespace, so (in general) Abatab will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.</p>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="116" sourceendlinenumber="116">For example, if a variable has a value of &quot;<code>_ AValue_</code>&quot; (where the &quot;<code>_</code>&quot; character is whitespace), it will be converted to &quot;<code>avalue</code>&quot;. This way if the user has the incorrect casing for a setting called &quot;<code>EnableAllLogs</code>&quot;, Abayab will still be able to apply logic because it checks against &quot;<code>enablealllogs</code> (which isn&#39;t very user friendly).</p>
<h2 id="multiple-values" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="118" sourceendlinenumber="118">Multiple values</h2>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="120" sourceendlinenumber="120">Multiple values are stored in strings, with each value seperated by a <code>-</code>&quot; character. For example, the following values:</p>
<pre sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="122" sourceendlinenumber="126"><code class="lang-#bash">Apple  
Pear
Orange
</code></pre><p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="128" sourceendlinenumber="128">would apprear as:</p>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="130" sourceendlinenumber="130"><code>Apple-Pear-Orange</code></p>
<hr>
<p sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="141" sourceendlinenumber="141">Abatab is developed by <a href="https://github.com/APrettyCoolProgram" data-raw-source="[A Pretty Cool Program][a-pretty-cool-program-url]" sourcefile="../../docs/man/logging/man_logging_home.md" sourcestartlinenumber="141" sourceendlinenumber="141">A Pretty Cool Program</a></p>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
                <h5>In This Article</h5>
                <div></div>
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../../styles/docfx.js"></script>
    <script type="text/javascript" src="../../styles/main.js"></script>
  </body>
</html>
